mapObsoleteClassesToTemps: oldClasses
	"Map the old classes to temporary classes.
	These temporary classes will survive the #become:
	operation and be used as the class of any instances
	or subclasses of the obsolete classes."
	| oldMeta tempMeta obsoleteClasses |
	obsoleteClasses _ IdentityDictionary new: oldClasses size.
	oldClasses do:[:oldClass| 
		"Note: If a class is getting obsolete here so is its metaclass"
		oldMeta _ oldClass isMeta ifTrue:[oldClass] ifFalse:[oldClass class].
		tempMeta _ obsoleteClasses at: oldMeta ifAbsentPut:[oldMeta clone].
		oldClass isMeta ifFalse:[
			tempMeta adoptInstance: oldClass from: oldMeta.
			obsoleteClasses at: oldClass put: tempMeta soleInstance.
			"Note: If we haven't mutated the instances of the old class to the new
			layout we must do it here."
			oldClass autoMutateInstances ifFalse:[
				tempMeta soleInstance updateInstancesFrom: oldClass]]].
	"Fix the superclasses of the clones"
	obsoleteClasses keysAndValuesDo:[:old :temp|
		temp superclass: 
			(obsoleteClasses 
				at: temp superclass
				"Might be a subclass of a live class"
				ifAbsent:[temp superclass])].
	"And install new method dictionaries"
	obsoleteClasses valuesDo:[:temp|
		temp methodDictionary: temp methodDictionary copy.
	].
	^obsoleteClasses