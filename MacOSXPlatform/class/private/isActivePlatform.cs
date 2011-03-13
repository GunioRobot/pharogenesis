isActivePlatform
	^SmalltalkImage current platformName = 'Mac OS' and:[SmalltalkImage current osVersion asNumber >= 1000]