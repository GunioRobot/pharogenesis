expandAll
	"Expand all windows"
	(SystemWindow windowsIn: self world satisfying: [:w | w isCollapsed])
		reverseDo: [:w | w collapseOrExpand.  self world displayWorld]