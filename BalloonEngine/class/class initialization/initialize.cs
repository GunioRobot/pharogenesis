initialize
	"BalloonEngine initialize"
	BufferCache _ WeakArray new: 1.
	Smalltalk garbageCollect. "Make the cache old"
	CacheProtect _ Semaphore forMutualExclusion.
	Times _ WordArray new: 10.
	Counts _ WordArray new: 10.
	BezierStats _ WordArray new: 4.
	Debug ifNil:[Debug _ false].