isStepping: aMorph
	"Return true if the given morph is in the step list."

	stepList do: [:entry | entry first == aMorph ifTrue: [^ true]].  "already stepping"
	^ false