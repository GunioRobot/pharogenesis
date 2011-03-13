request: messageString  initialAnswer: aString  avoiding: aRect
	"Answer an instance of me whose question is messageString. Once the user provides an answer, then evaluate aBlock. If centered, aBoolean, is false, display the view of the instance at aPoint; otherwise display it with its center at aPoint.   
	2/5/96 sw: This variant tries to avoid obscuring aRect
	2/6/96 sw: fixed to return the user's response"

	self request: messageString displayAt: aRect bottomLeft centered: false action: [:response | response] initialAnswer: ''.
	^ response