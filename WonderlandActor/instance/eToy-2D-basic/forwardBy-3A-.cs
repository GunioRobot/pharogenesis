forwardBy: distance
	"Note: This assumes we're moving in centimeters - common Alice reference is meter!"
	self move: forward distance: (distance * 0.01) duration: rightNow.