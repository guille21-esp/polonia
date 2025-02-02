#include "libcomp.h"
#include <iostream>

int Computer::counter = 0;

Computer::Computer(std::string ip, std::string bios, std::string name) 
    : ipAddress(ip), biosName(bios), name(name) {
    counter++;
}

Computer::Computer(std::string bios, std::string name) 
    : biosName(bios), name(name) {
    counter++;
}

Computer::Computer() {
    counter++;
}

void Computer::startComputer(const std::string& ip) {
    ipAddress = ip;
}

void Computer::shutDownComputer() {
    ipAddress = "";
}

std::string Computer::getIpAddress() const { return ipAddress; }
void Computer::setIpAddress(const std::string& ip) { ipAddress = ip; }

std::string Computer::getBiosName() const { return biosName; }
void Computer::setBiosName(const std::string& bios) { biosName = bios; }

std::string Computer::getName() const { return name; }
void Computer::setName(const std::string& name) { this->name = name; }

int Computer::getCompsNum() { return counter; }

Server::Server(std::string ip, std::string bios, std::string name, std::string type) 
    : Computer(ip, bios, name), type(type) {}

Server::Server() {}

std::string Server::getType() const { return type; }
void Server::setType(const std::string& type) { this->type = type; }

void Server::shutDownComputer() {
    std::cout << "Are you sure you want to shut down the server? (y/n): ";
    char choice;
    std::cin >> choice;
    if (choice == 'y') {
        ipAddress = "";
    } else {
        std::cout << "Server still on\n";
    }
}
