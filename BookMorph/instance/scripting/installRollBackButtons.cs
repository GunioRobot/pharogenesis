installRollBackButtons
	| all |
	"In each script in me, put a versions button it the upper right."

	all _ IdentitySet new.
	self allMorphsAndBookPagesInto: all.
	all _ all select: [:mm | mm class = MethodMorph].
	all do: [:mm | mm installRollBackButtons: self].