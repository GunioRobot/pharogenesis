getPackage
	self getSelector ifNil: [
			^ PackageInfo named:(
					self getClass ifNil: [self getSystemCategory] 
									ifNotNilDo: [:c | c category copyUpTo:  $-])].
	^ PackageOrganizer default 
			packageOfMethod: 
					(MethodReference class: self getClass
										selector: self getSelector)
			ifNone: [PackageInfo named: (self getClass category copyUpTo:  $-)] 