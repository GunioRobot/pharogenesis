show2

    " B3DDemoSolids new show2"

     | view |

  self createScene2.
  (view := B3DTutorialScenePresenterMorph new)
      source: self description: #descriptionScene2;
    scene: scene.

  view rotateX: 25.4.
  view openInSystemWindow.