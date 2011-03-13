justDuplicatedFrom: aDonor
	"A hook so that after the Duplicate command is issued by a user, the dup gets a chance to get things right.  If a costumee (Player) is involved, the duplication involved the creation of a fresh Player subclass rather than another instance of the original." 

	costumee ifNotNil:
		[costumee justDuplicatedFrom: aDonor costumee]