show1

    " B3DDemoSolids new show1"

     | view |

  self createScene1.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene1;
     scene: scene.

  view rotateX: 25.4.
  view openInSystemWindow.