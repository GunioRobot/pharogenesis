isActiveDirectoryClass
	"Does this class claim to be that properly active subclass of FileDirectory for this platform?
	On Acorn, the test is whether systemAttribute 1001 = 'RiscOS' (on newer VMs) or if the primPathNameDelimiter is $. (on older ones), which is what we would like to use for a dirsep if only it would work out. See pathNameDelimiter for more woeful details - then just get on and enjoy Squeak"
	| attr |
	attr _ Smalltalk getSystemAttribute: 1001.
	attr isNil ifFalse:[^attr = 'RiscOS'].
	^self primPathNameDelimiter = $.
