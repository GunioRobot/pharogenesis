justClonedFrom: aDonor
	"A hook so that after the Duplicate command is issued by a user, the clone gets a chance to get things right." 
	costumee ifNotNil:
		[costumee justClonedFrom: aDonor costumee]