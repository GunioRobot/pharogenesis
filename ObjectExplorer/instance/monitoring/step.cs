step
	"If there's anything in my monitor list, see if the strings have changed."
	| string changes |
	changes _ false.
	self monitorList keysAndValuesDo: [ :k :v |
		k ifNotNil: [
			k refresh.
			(string _ k asString) ~= v ifTrue: [ self monitorList at: k put: string. changes _ true ].
		]
	].
	changes ifTrue: [ | sel |
		sel _ currentSelection.
		self changed: #getList.
		self noteNewSelection: sel.
	].
	self monitorList isEmpty ifTrue: [ ActiveWorld stopStepping: self selector: #step ].