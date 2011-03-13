linesOfCode
	"An approximate measure of lines of code.
	Includes comments, but excludes blank lines."
	| lines |
	lines _ self methodDict values inject: 0 into: [:sum :each | sum + each linesOfCode]. 
	self isMeta 
		ifTrue: [^ lines]
		ifFalse: [^ lines + self class linesOfCode]