compile: code notifying: requestor trailer: bytes ifFail: failBlock
	"For backward compatibility."
	| selector |
	self compile: code notifying: requestor trailer: bytes
		ifFail: failBlock
		elseSetSelectorAndNode: [:sel :node | selector _ sel].
	^ selector