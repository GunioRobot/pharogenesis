keyframeData
	"Subchunk of scene"
	
	| data info|
	data := Dictionary new.
	data at: #info put: (info := Dictionary new).
	self recognize: #(
		(16rB00A keyframeHeader header)
		(16rB008 twoLongs segments)
		(16rB009 long current)
		(16rB001 node ambientLight)
		(16rB002 node objects)
		(16rB003 node cameras)
		(16rB004 node targets)
		(16rB005 node lights)
		(16rB006 node lightTargets)
		(16rB007 node spotlights)
		)
		do: [:item |
			#header == item key ifTrue: [
				info addAll: item value] ifFalse: [
			#segments == item key ifTrue: [
				info add: item.
				log == nil ifFalse: [log crtab: indent+1; print: item value]] ifFalse: [
			#current == item key ifTrue: [
				info add: item.
				log == nil ifFalse: [log crtab: indent+1; print: item value]] ifFalse: [
			(data at: item key ifAbsentPut: [Dictionary new]) 
				add: item value]]]].
	^data