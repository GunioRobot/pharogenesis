bigFactorial: anInteger depth: depth 
	"Computationally very expensive!"
	depth > 1
		ifTrue: [^ (self bigFactorial: anInteger depth: depth - 1) factorial]
		ifFalse: [^ anInteger factorial]