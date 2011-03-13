ifCurtailed: aBlock
	"Evaluate the receiver with an abnormal termination action.
	 Evaluate aBlock only if execution is unwound during execution
	 of the receiver.  If execution of the receiver finishes normally
	 do not evaluate aBlock."

	<primitive: 198>
	^self valueNoContextSwitch