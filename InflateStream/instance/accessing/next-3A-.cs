next: anInteger 
	"Answer the next anInteger elements of my collection.  overriden for simplicity"
	| newArray |

	"try to do it the fast way"
	position + anInteger < readLimit ifTrue: [
		newArray _ collection copyFrom: position + 1 to: position + anInteger.
		position _ position + anInteger.
		^newArray
	].

	"oh, well..."
	newArray _ collection species new: anInteger.
	1 to: anInteger do: [:index | newArray at: index put: (self next ifNil: [ ^newArray copyFrom: 1 to: index - 1]) ].
	^newArray