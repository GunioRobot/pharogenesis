resizeTopToBottom: height leftToRight: width frontToBack: thickness
	"Resize the object by the specified amount over 1 second using the Gently animation style."

	^ (self resizeTopToBottom: height leftToRight: width frontToBack: thickness
				duration: 1.0
				style: gently).

