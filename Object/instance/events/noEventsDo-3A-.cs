noEventsDo: aBlock
	"Evaluate aBlock while ensuring that the receiver will not trigger
	any events. Answer the result of evaluating aBlock."

	| events |
	events _ self myEvents.
	^ [self myEvents: nil. aBlock value] ensure: [self myEvents: events]