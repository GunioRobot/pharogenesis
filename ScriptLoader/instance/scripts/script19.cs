script19
	"
	Morphic team new versions
		Mantis-1092-MorphDropFix, fix by Edgar De Cleene (edc) and Scott  Wallace (sw)
Mantis-0503-TargetSighting, fix by Jerome Peace (wiz)
Mantis-1015-SnapView, fix by Jerome Peace (wiz)
Mantis-1771-ClickExerciser, fix by Jerome Peace (wiz)
Mantis-1625-Thumbnails, fix by Jerome Peace (wiz)
Mantis-1484-TrashHalo, fix by Jerome Peace (wiz)
Mantis-1454-ArrowPrototypeFix, fix by Jerome Peace (wiz)
Mantis-1347-ListDoubleClick, fix by Jerome Peace (wiz)
Reviewed by Juan Vuletich (jmv)
		
		Pay attention the order is important: first Etoys, then Morphic then Morphic Extra and
		this is not working with merging (ie default MC behavior.
	"
	self loadOneAfterTheOther: #('EToys-jmv.5.mcz' 'Morphic-jmv.58.mcz' 'MorphicExtras-jmv.9.mcz') merge: false.
