pushArgs: args from: sendr 
	"Simulates action of the value primitive."

	args size ~= nargs ifTrue: [^self error: 'incorrect number of args'].
	self stackp: 0.
	args do: [:arg | self push: arg].
	sender _ sendr.
	pc _ startpc