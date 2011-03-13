testRemoveThenRename
	categorizer removeCategory: #unreal.
	categorizer renameCategory: #abc toBe: #unreal.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''unreal'' a b c)
'