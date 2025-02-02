#ifndef LIBCOMP_H
#define LIBCOMP_H

#include <iostream>
#include <string>

class Computer {
protected:
    std::string name;
    std::string ipAddress;
    std::string biosName;
    static int counter;

public:
    Computer(std::string ip, std::string bios, std::string name);
    Computer(std::string bios, std::string name);
    Computer();

    void startComputer(const std::string& ip);
    void shutDownComputer();

    std::string getIpAddress() const;
    void setIpAddress(const std::string& ip);

    std::string getBiosName() const;
    void setBiosName(const std::string& bios);

    std::string getName() const;
    void setName(const std::string& name);

    static int getCompsNum();
};

class Server : public Computer {
private:
    std::string type;

public:
    Server(std::string ip, std::string bios, std::string name, std::string type);
    Server();

    std::string getType() const;
    void setType(const std::string& type);
    void shutDownComputer();
};

#endif
