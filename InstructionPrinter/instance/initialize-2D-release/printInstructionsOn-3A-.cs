printInstructionsOn: aStream 
	"Append to the stream, aStream, a description of each bytecode in the 
	instruction stream."
	
	| end |
	stream _ aStream.
	scanner _ InstructionStream on: method.
	end _ method endPC.
	oldPC _ scanner pc.
	[scanner pc <= end]
		whileTrue: [scanner interpretNextInstructionFor: self]