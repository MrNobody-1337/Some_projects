#include "pch.h"
#include <iostream>
#include <conio.h>
#include<Windows.h>
using namespace std;

char board[9];
char player = ' ';
bool check = 1;

enum Direction {UP, RIGHT, DOWN, LEFT, PUSH, STOP};
Direction direction;

short int x = 1, y = 2;

void fillIn() {
	for (int g = 0; g < 9; g++) {
		board[g]=' ';
	}
}
void draw() {
	system("cls");
	cout <<board[0]<< "|" << board[1] << "|" <<board[2]<< endl;
	cout << "-----" << endl;
	cout << board[3]<<"|"<<board[4]<<"|" <<board[5]<< endl;
	cout << "-----" << endl;
	cout <<board[6]<< "|" << board[7] << "|"<<board[8]<< endl;
}
void whoMoves() {
	if (check) {
		player = 'X';
		check = 0;
	}
	else {
		player = 'O';
		check = 1;
	}
}
void add() {
	int final=0;
	final = x + y * 3;
	if(board[final]!='X'&&board[final]!='O') board[final] = player;
	whoMoves();
}
void move() {
	if (direction == UP) y--;
	if (direction == DOWN) y++;
	if (direction == LEFT) x--;
	if (direction == RIGHT) x++;
	if (direction == PUSH) add();
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD doublePos = { x * 2, y * 2 };
	SetConsoleCursorPosition(hConsole, doublePos);
	direction = STOP;
}
char winner() {
	for (int g = 0; g < 3; g++) {
		if ((board[g * 3] == board[g * 3 + 1] && board[g * 3 + 1] == board[g * 3 + 2]) && board[g*3] != ' ')
			return board[g*3];
		else if ((board[g] == board[g + 3] && board[g + 3] == board[g + 6])&&board[g]!=' ') 
			return board[g];
		else if (((board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]))&& board[4] != ' ')
			return board[4]; 
	}
	return 0;
}
void result(char win) {
	setlocale(LC_ALL, "RUS");
	if (win == 'X') cout << "Кресты форева!!!";
	else cout << "Вы нуль, сударь.";
}
int main(){
	fillIn();
	whoMoves();
	while (!winner()) {
		draw();
		if (_kbhit()) {
			char current;
			current = _getch();
			if (current == 'w') direction = UP;
			if (current == 'a') direction = LEFT;
			if (current == 's') direction = DOWN;
			if (current == 'd') direction = RIGHT;
			if (current == 'f') direction = PUSH;
		}
		move();
	}
	system("cls");
	result(winner());
}