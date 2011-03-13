emphasisAt: characterIndex
	"Answer the fontfor characters in the run beginning at characterIndex."
	| attributes emph |
	self size = 0 ifTrue: [^ 0].	"null text tolerates access"
	emph := 0.
	attributes := runs at: characterIndex.
	attributes do: 
		[:att | emph := emph bitOr: att emphasisCode].
	^ emph
	