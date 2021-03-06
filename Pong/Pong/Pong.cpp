#include "pch.h"
#include <iostream>
#include <ctime>
#include<time.h>
#include<conio.h>
#include<Windows.h>
using namespace std;
//направления
enum eDirection {
	STOP, LEFT, UPLEFT, DOWNLEFT, RIGHT, UPRIGHT, DOWNRIGHT
};
class Ball {
private:
	int x = 0, y = 0;
	int orig_x = 0, orig_y = 0;
	eDirection direction;
public:
	Ball(int posX, int posY) : orig_x(posX), orig_y(posY), x(posX), y(posY)
	{
		direction = STOP;
	}
	void Reset() {
		x = orig_x;
		y = orig_y;
		direction = STOP;
	}
	void change_direction(eDirection d) {
		direction = d;
	}
	void randomDirection() {
		//srand(time(0));
		direction = (eDirection)((rand() % 6 + 1));
	}
	inline int getX() {return x;}
	inline int getY() {return y;}
	inline eDirection getDirection() {return direction;}
	void move() {
		switch (direction) {
			case STOP:
				break;
			case LEFT:
				x--;
				break;
			case RIGHT:
				x++;
				break;
			case UPLEFT:
				x--;
				y--;
				break;
			case DOWNLEFT:
				x--;
				y++;
				break;
			case UPRIGHT:
				x++;
				y--;
				break;
			case DOWNRIGHT:
				x--;
				y++;
				break;
			default:
				break;
		}
	}
	friend ostream &operator<<(ostream &o, Ball c) {
		o << "Ball [" << c.x << "," << c.y << "][" << c.direction << "]";
		return o;
	}
};
class Paddle {
private:
	int x = 0, y = 0;
	int orig_x = 0, orig_y = 0;
public:
	Paddle() {
		x = y = 0;
	}
	Paddle(int posX, int posY): Paddle() {
		orig_x = x = posX;
		orig_y = y = posY;
	}
	inline void Reset() { x = orig_x; y = orig_y; }
	inline int getX() { return x; }
	inline int getY() { return y; }
	inline void moveUp() { y--; }
	inline void moveDown() { y++; }
	friend ostream &operator<<(ostream &o, Paddle c) {
		o << "Paddle [" << c.x << "," << c.y << "]";
		return o;
	}
};
class gameBuild {
private:
	int width = 0, height = 0;
	int score1 = 0, score2 = 0;
	char up1, down1, up2, down2;
	bool quit = 1;
	Ball *ball;
	Paddle *player1;
	Paddle *player2;
public:
	gameBuild(int w, int h) {
		srand(time(NULL));
		quit = false;
		up1 = 'w'; up2 = 'i';
		down1 = 's'; down2 = 'k';
		score1 = score2 = 0;
		width = w;
		height = h;
		ball = new Ball(w / 2, h / 2);
		player1 = new Paddle(1, h / 2 - 3);
		player2 = new Paddle(w - 2, h / 2 - 3);
	}
	~gameBuild() {
		delete ball, player1, player2;
	}
	void scoreUp(Paddle *player) {
		if (player == player1) {
			score1++;
		}
		else if(player == player2) {
			score2++;
		}
		ball->Reset();
		player1->Reset();
		player2->Reset();
	}
	void draw() {
		system("cls");
		for (int i = 0; i < width + 2; i++) {
			cout << "\xB2";
		}
		cout << endl;
		for (int i = 0/*represents y*/; i < height; i++) {
			for (int j = 0/*represents x*/; j < width; j++) {
				int ballx = ball->getX();
				int bally = ball->getY();
				int player1x = player1->getX();
				int player2x = player2->getX();
				int player1y = player1->getY();
				int player2y = player2->getY();
				if (j == 0) {
					cout << "\xB2";
				}
				if (ballx == j && bally == i) {
					cout << (char)003;//ball
				}
				else if (player1x == j && player1y == i) {
					cout << (char)219;//player 1
				}
				else if (player1x == j && player1y+1 == i) {
					cout << (char)219;//player 1
				}
				else if (player1x == j && player1y+2 == i) {
					cout << (char)219;//player 1
				}
				else if (player1x == j && player1y+3 == i) {
					cout << (char)219;//player 1
				}
				
				else if (player2x == j && player2y == i) {
					cout <<(char)219;//player 2
				}
				else if (player2x == j && player2y +1== i) {
					cout << (char)219;//player 2
				}
				else if (player2x == j && player2y+2 == i) {
					cout << (char)219;//player 2
				}
				else if (player2x == j && player2y +3== i) {
					cout << (char)219;//player 2
				}
				else {
					cout << " ";
				}
				if (j == width - 1) {
					cout << "\xB2";
				}
			}
			cout << endl;
		}
		for (int i = 0; i < width + 2; i++) {
			cout << "\xB2";
		}
		cout << endl;
		cout << "Score 1: " << score1 <<endl<<"Score 2: "<< score2 << endl;;
	}
	void input() {
		ball->move();
		int ballx = ball->getX();
		int bally = ball->getY();
		int player1x = player1->getX();
		int player2x = player2->getX();
		int player1y = player1->getY();
		int player2y = player2->getY();
		if (_kbhit()) {
			char current = _getch();
			if (current == up1) {
				if (player1y > 0) {
					player1->moveUp();
				}
			}
			if (current == up2) {
				if (player2y > 0) {
					player2->moveUp();
				}
			}
			if (current == down1) {
				if (player1y+4 <height) {
					player1->moveDown();
				}
			}
			if (current == down2) {
				if (player2y+4 <height) {
					player2->moveDown();
				}
			}
			if (ball->getDirection() == STOP) {
				ball->randomDirection();
			}
			if (current == 'q') {
				quit = true;
			}
		}
	}
	void logic(){
		int ballx = ball->getX();
		int bally = ball->getY();
		int player1x = player1->getX();
		int player2x = player2->getX();
		int player1y = player1->getY();
		int player2y = player2->getY();
		//left paddle
		for (int i = 0; i < 4; i++) {
			if (ballx == player1x + 1) {
				if (bally == player1y + i) {
					ball->change_direction((eDirection)((rand()%3)+4));
				}
			}
		}
		//right paddle
		for (int i = 0; i < 4/*represents paddle's length*/; i++) {
			if (ballx == player2x - 1) {
				if (bally == player2y + i) {
					ball->change_direction((eDirection)((rand() % 3) + 1));
				}
			}
		}
		//bottom wall
		if (bally == height - 1/*to bounce off the wall,not to go into it*/) {
			ball->change_direction(ball->getDirection() == DOWNRIGHT ? UPRIGHT : UPLEFT);
		}
		//top wall
		if (bally == 0/*to bounce off the wall,not to go into it*/) {
			ball->change_direction(ball->getDirection() == UPRIGHT ? DOWNRIGHT : DOWNLEFT);
		}
		//right wall
		if (ballx == width - 1) {
			scoreUp(player1);
		}
		//left wall
		if (ballx == 0) {
			scoreUp(player2);
		}
	}
	void run() {
		while (!quit) {
			draw();
			input();
			logic();
		}
	}
};
int main() {
	gameBuild game (40, 20);
	game.run();
	return 0;
}
