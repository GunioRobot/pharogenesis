calcTurtlesCount

	turtleCount _ 0.
	turtlesDict do: [:a | turtleCount _ turtleCount + a size].

	SmalltalkImage current vmParameterAt: 5 put: ((turtleCount * 3) min: 16000 max: 4000).
	SmalltalkImage current vmParameterAt: 6 put: ((turtleCount * 6) min: 32000 max: 8000).
