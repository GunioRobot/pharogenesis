referingMethodsDefinedInSubclasses: aClass 
	| r |
	r := self methodsCalledForClass: aClass. 
	subclasses := aClass allSubclasses.
	subclasses remove: aClass