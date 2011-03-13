removeAlarm: aSelector for: aTarget
	"Remove the alarm with the given selector"
	| alarm |
	alarm _ self alarms 
		detect:[:any| any receiver == aTarget and:[any selector == aSelector]]
		ifNone:[nil].
	alarm == nil ifFalse:[self alarms remove: alarm].