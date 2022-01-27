import { FormControl, FormGroup, Validators } from "@angular/forms";

export const CONST_REQUESTS_PAGE: {
    REQUEST_FORM: FormGroup;
} = {
    REQUEST_FORM: new FormGroup({
        detail: new FormControl('', Validators.required)
    })
}
