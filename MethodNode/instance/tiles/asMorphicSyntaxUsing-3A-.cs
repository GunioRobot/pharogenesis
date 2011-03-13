asMorphicSyntaxUsing: aClass
	
	| morph |
	(morph _ aClass 
		column: #method 
		on: self)
		borderWidth: 0.
	self asMorphicSyntaxIn: morph.
	block _ morph submorphs last.
	block submorphs size = 1 ifTrue: [^ morph].	"keep '^ self' if that is the only thing in method"
	block submorphs last decompile string = '^  self ' ifTrue: [
		block submorphs last delete].
	^ morph