reInitializeDependentsFields
	"Object reInitializeDependentsFields"
	| oldFields |
	oldFields _ DependentsFields.
	DependentsFields _ WeakIdentityKeyDictionary new.
	oldFields keysAndValuesDo:[:obj :deps|
		deps do:[:d| obj addDependent: d]].
