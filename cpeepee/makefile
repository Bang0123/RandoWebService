SRC_CPP := $(shell find ./src -name *.cpp)
OBJ_FOR_CLEAN_F := $(shell find ./src -name *.o)
OBJ_FOR_CLEAN_H := $(shell find ./src -name *.gch)
SRC_CPP_O := $(patsubst %.cpp,%.o,$(SRC_CPP))

CC := g++
CFLAGS := -Wall -g

TARGET := build/main.out
.PONY: clean

all: $(SRC_CPP_O) copy_assets
	$(CC) $(CFLAGS) $(SRC_CPP_O) -o $(TARGET)

run_main: clean all
	$(TARGET)

%.o: %.cpp
	$(CC) $(CFLAGS) -c $^ -o $@

clean:
	rm -rf $(OBJ_FOR_CLEAN_F)
	rm -rf $(TARGET)
	rm -rf build/assets

deep_clean: clean
	rm -rf $(SRC_CPP_O)
	rm -rf $(OBJ_FOR_CLEAN_H)
	

copy_assets:
	cp -r assets build