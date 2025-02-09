export class IndexController {
    public renderIndex(req: Request, res: Response): void {
        res.render('index', { title: 'Home' });
    }
}