// main.cpp
#include "libcomp.h"
#include <iostream>
#include <vector>
#include <fstream>
#include <cstdlib>
#include <ctime>
#include <chrono>
#include <iomanip>
#include <ctime>

std::vector<Computer*> net(10);
std::ofstream logFile("log.txt", std::ios::app);

std::string randomIP() {
    int a = rand() % 256;
    int b = rand() % 256;
    int c = rand() % 256;
    int d = rand() % 256;
    return std::to_string(a) + "." + std::to_string(b) + "." + std::to_string(c) + "." + std::to_string(d);
}


void displayComputers() {
    std::cout << "Devices in net:\n";
    for (auto* comp : net) {
        if (comp) {
            std::cout << comp->getName() << "\t" 
                      << comp->getIpAddress() << "\t" 
                      << comp->getBiosName() << "\n";
        }
    }
}

void menu() {
    bool quit = false;
    while (!quit) {
        std::cout << std::endl;
        std::cout << "Available devices: " << std::endl;
        for (int i = 0; i < net.size(); i++) {
            if (net[i]) {
                if (net[i] == net[0]) {
                    std::cout << "Server " << net[i]->getIpAddress() << std::endl;
                } else {
                    std::cout << "Computer " << net[i]->getIpAddress() << std::endl;
                }
            }
        }

        std::cout << "\n*---------Menu-----------*\n"
                  << "1. Start server\n"
                  << "2. Start computers\n"
                  << "3. Display Devices\n"
                  << "4. Shut down computer\n"
                  << "5. Shut down all computers\n"
                  << "6. See the log\n"
                  << "7. Shut down server\n"
                  << "8. Quit\n"
                  << "Choose option: ";
        int option;
        std::cin >> option;

        auto time = std::chrono::system_clock::now();
        std::time_t currentTime = std::chrono::system_clock::to_time_t(time);

        switch (option) {
            case 1:
                std::cout << "Starting server...\n";
                net[0]->startComputer(randomIP());
                logFile << std::put_time(std::localtime(&currentTime), "%Y-%m-%d %H:%M:%S") << "server started "  << ", IP: " << net[0]->getIpAddress() << std::endl;
                break;
            case 2:
                std::cout << "Starting computers...\n";
                for (size_t i = 1; i < net.size(); i++) {
                    if (!net[i]->getIpAddress().empty()) continue;
                    net[i]->startComputer(randomIP());
                }
                logFile << std::put_time(std::localtime(&currentTime), "%Y-%m-%d %H:%M:%S") << "all computers started " << std::endl;
                break;
            case 3:
                displayComputers();
                break;
            case 4:
                std::cout << "Enter IP to shut down: ";
                {
                    std::string ip;
                    std::cin >> ip;
                    for (auto* comp : net) {
                        if (comp && comp->getIpAddress() == ip) {
                            comp->shutDownComputer();
                            std::cout << "Computer shut down.\n";
                            break;
                        }
                    }
                    logFile << std::put_time(std::localtime(&currentTime), "%Y-%m-%d %H:%M:%S") << "computer shut down " << ", IP: " << ip << std::endl;
                }
                break;
            case 5:
                std::cout << "Shutting down all computers...\n";
                for (auto* comp : net) {
                    if (comp) comp->shutDownComputer();
                }
                logFile << std::put_time(std::localtime(&currentTime), "%Y-%m-%d %H:%M:%S") << "all computers shut down " << std::endl;
                break;
            case 6:
                std::cout << "Log file saved to log.txt\n";
                break;
            case 7:
                std::cout << "Shutting down server...\n";
                net[0]->shutDownComputer();
                logFile << std::put_time(std::localtime(&currentTime), "%Y-%m-%d %H:%M:%S") << "server shut down " << ", IP: " << net[0]->getIpAddress() << std::endl;
                break;
            case 8:
                quit = true;
                break;
            default:
                std::cout << "Invalid option.\n";
        }
    }
}

int main() {
    srand(time(0));
    net[0] = new Server("255.255.255.255", "DHCP", "server_one", "net_server");
    

    for (size_t i = 1; i < net.size(); i++) {
        net[i] = new Computer("bios_" + std::to_string(i), "computer_" + std::to_string(i));
        net[i]->startComputer(randomIP());
    }
    menu();
    for (auto* comp : net) delete comp;
    return 0;
}
