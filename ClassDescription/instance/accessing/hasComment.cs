hasComment
	"return whether this class truly has a comment other than the default"
	| org |
	org := self theNonMetaClass organization.
	^org classComment notNil and: [
		org classComment isEmpty not ].
