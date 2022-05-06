# for C++ define CC = g++
CC = gcc
CFLAGS = -g -Wall -03
TARGET = lbsconverter

# typing 'make' will invoke this
default: $(TARGET)

# create executable
$(TARGET): main.o util.o
	$(CC) $(CFLAGS) -o $(TARGET) main.o util.o

# make object files
main.o: main.c util.h
	$(CC) $(CFLAGS) -c main.c

util.o: util.c util.h
	$(CC) $(CFLAGS) -c util.c

# To start over, type 'make clean'.
clean:
	rm -fv $(TARGET) *.o