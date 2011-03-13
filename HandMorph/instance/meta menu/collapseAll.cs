collapseAll
	"Collapse all windows"
	(SystemWindow windowsIn: self world satisfying: [:w | w isCollapsed not])
		reverseDo: [:w | w collapseOrExpand.  self world displayWorld]