initializeCommonRequestStrings
	"Initialize an array of common request strings.  2/1/96 sw"

	CommonRequestStrings _ StringHolder new contents: 
'Utilities emergencyCollapse
Utilities closeAllDebuggers
Sensor keyboard
Cursor normal show
ParagraphEditor abandonChangeText
----------------------------------
Preferences enable: #cmdDotEnabled
Form fromUser bitEdit
Display border: (0@0 extent: 640@480) width: 2
----------------------------------
Undeclared inspect
Undeclared removeUnreferencedKeys; inspect
Transcript clear
ChangeSorter removeEmptyUnnamedChangeSets
Utilities reconstructTextWindowsFromFileNamed: ''TextWindows''.
Utilities storeTextWindowContentsToFileNamed: ''TextWindows''.
self currentHand attachMorph: (FrameRateMorph new contents: ''FrameRate'').
----------------------------------
ChangeSorter removeEmptyUnnamedChangeSets
ChangeSorter reorderChangeSets.
Utilities grabScreenAndSaveOnDisk'

"Utilities initializeCommonRequestStrings"