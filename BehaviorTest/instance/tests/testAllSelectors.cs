testAllSelectors
	self assert: ProtoObject allSelectors = ProtoObject selectors.
	self assert: Object allSelectors = (Object selectors union: ProtoObject selectors).
	self assert: (Object allSelectorsBelow: ProtoObject) = (Object selectors).