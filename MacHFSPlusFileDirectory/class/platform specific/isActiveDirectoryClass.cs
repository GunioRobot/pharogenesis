isActiveDirectoryClass
	"Ok, lets see if we support HFS Plus file names, the long ones"

	^ (self pathNameDelimiter = self primPathNameDelimiter) and: [(SmalltalkImage current  getSystemAttribute: 1201) notNil and: [(SmalltalkImage current getSystemAttribute: 1201) asNumber > 31]]