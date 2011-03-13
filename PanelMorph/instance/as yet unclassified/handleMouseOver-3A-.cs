handleMouseOver: anEvent
	"System level event handling."
	
	(self handlesMouseOver: anEvent) ifTrue:[
		anEvent wasHandled: true.
		self mouseOver: anEvent]