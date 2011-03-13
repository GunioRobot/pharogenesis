browseFullForClass: aClass method: aSelector from: aController
	"Create and schedule a full Browser and then select the class of the master object being inspected.  1/12/96 sw"

	aController controlTerminate.
	self browseFullForClass: aClass method: aSelector.
	aController controlInitialize