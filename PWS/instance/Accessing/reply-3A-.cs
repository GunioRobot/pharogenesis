reply: aString
	"Send back part of the reply. If we are in roll forward mode just do nothing."
	"Transcript show: 'R',aString ; cr."
	connection ifNotNil: [ connection sendData: aString ]