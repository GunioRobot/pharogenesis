serve: aSocket
	"Create an instance and initialize it from aSocket."

	| inst |
	inst := self new.
	([ inst initializeFrom: aSocket; getReply ] ifError: [ :msg :rec | inst report: msg for: rec ])
	 ~~ #inBackground ifTrue: [ aSocket closeAndDestroy ].
	^inst log contents
