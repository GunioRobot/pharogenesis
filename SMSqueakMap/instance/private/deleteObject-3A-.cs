deleteObject: anObject 
	"Delete an object, remove it from objects.
	This method is called from the #delete method of
	anObject so it will take care of the rest of the
	cleaning up. Clear the valid caches."

	objects removeKey: anObject id.
	self clearCachesFor: anObject
