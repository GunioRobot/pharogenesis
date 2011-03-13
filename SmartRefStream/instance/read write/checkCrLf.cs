checkCrLf
	| save isCrLf cc prev loneLf |
	"Watch for a file that has had all of its Cr's converted to CrLf's.  Some unpacking programs like Stuffit 5.0 do this by default!"

	save _ byteStream position.
	isCrLf _ false.  loneLf _ false.
	cc _ 0.
	350 timesRepeat: [
		prev _ cc.
		(cc _ byteStream next) = 16r0A "Lf" ifTrue: [
			prev = 16r0D "Cr" ifTrue: [isCrLf _ true] ifFalse: [loneLf _ true]].
		].
	isCrLf & (loneLf not) ifTrue: [
		self inform: 'Carriage Returns in this file were converted to CrLfs 
by an evil unpacking utility.  Please set the preferences in 
StuffIt Expander to "do not convert file formats"'].
	byteStream position: save.
