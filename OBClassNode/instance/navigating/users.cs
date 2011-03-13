users
	^ (SystemNavigation default allCallsOn: (theClass environment associationAt: theClass name))
		collect: [:ref | OBClassRefNode on: self name inMethod: ref]