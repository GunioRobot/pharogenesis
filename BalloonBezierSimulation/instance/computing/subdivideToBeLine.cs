subdivideToBeLine
	"Not a true subdivision.
	Just return a line representing the receiver and fake me to be of zero height"
	| line |
	line _ BalloonLineSimulation new.
	line start: start.
	line end: end.
	"Make me invalid"
	end _ start.
	via _ start.
	 ^line