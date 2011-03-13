transaction: aBlock
	"Execute aBlock and then make sure any modified SMObjects
	are committed to disk. We do this inside a mutex in order to
	serialize transactions. Transactions must be initiated from
	service methods in this class and not from inside the domain
	objects - otherwise they could get nested and a deadlock occurs."

"In first version of SM2 we simply set the isDirty flag,
when next client asks for updates, or 30 minutes has passed,
we checkpoint."

"	self mutex critical: ["
		aBlock value.
		isDirty := true
"	]"

"	self mutex critical: [
		dirtyList := OrderedCollection new.
		aBlock value.
		dirtyList do: [:obj | obj commit].
		dirtyList := nil
	]"