smartInspect
	"Like inspect, but for collections with only one element, inspects that element"
	^ self size == 1
		ifTrue:
			[self first smartInspect]
		ifFalse:
			[self inspect]