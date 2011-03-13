flushClassNameCache
	"This is an implementation efficiency: the collection of class names is 
	saved as a class variable and recomputed whenever the collection is 
	needed but has been previously flushed (set to nil).  Last touched sw 8/91"
	"Smalltalk flushClassNameCache"

	CachedClassNames _ nil