showProjectHierarchyInWindow
	"Open a window that displays the project hierarchy"

	| hierarchyString numberOfProjects |
	hierarchyString _ self projectHierarchy.
	numberOfProjects _ hierarchyString lineCount.
	((StringHolder new contents: hierarchyString)
		embeddedInMorphicWindowLabeled: 'Projects (', numberOfProjects printString, ') ', Date today printString, ' ', Time now printString)
			setWindowColor:  (Color r: 1.0 g: 0.829 b: 0.909);
			openInWorld: self currentWorld extent: (300 @ (((numberOfProjects * (TextStyle  defaultFont lineGrid + 4) min: (self currentWorld height - 50)))))

"Project showProjectHierarchyInWindow"
