morphsForInstanceData
	"Answer a list of the receiver's submorphs whose formal data are held in instances of the receiver's costumee.  At present, these are only the DataFieldMorphs; more to follow"
	^ self submorphs select: [:m | m holdsDataForEachInstance]